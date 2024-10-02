Sure! Below is an example of a Node.js API that connects to a SQL Server database for user authentication. This example uses the `mssql` package to connect to SQL Server, along with `bcrypt` for password comparison and `jsonwebtoken` for token generation.

### Prerequisites

1. **Install Required Packages**:
   Make sure you have the required packages installed:

   ```bash
   npm install express bcrypt jsonwebtoken body-parser mssql
   ```

2. **SQL Server Setup**:
   Ensure you have your SQL Server database ready with a table (e.g., `users`) containing columns for `username` and `password`.

### Example Code

Create a file named `server.js` and add the following code:

```javascript
const express = require('express');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const bodyParser = require('body-parser');
const sql = require('mssql');

const app = express();
const PORT = process.env.PORT || 3000;

// Middleware
app.use(bodyParser.json());

// SQL Server configuration
const dbConfig = {
  user: 'your_db_username',
  password: 'your_db_password',
  server: 'your_db_server', // e.g., 'localhost' or '127.0.0.1'
  database: 'your_db_name',
  options: {
    encrypt: true, // Use this if you're on Windows Azure
    trustServerCertificate: true // Change to true for local dev / self-signed certs
  }
};

// JWT secret key (keep this secret in a real application)
const JWT_SECRET = 'your_jwt_secret';

// Login endpoint
app.post('/login', async (req, res) => {
  const { username, password } = req.body;

  try {
    // Connect to the database
    await sql.connect(dbConfig);
    
    // Query to find user
    const result = await sql.query`SELECT * FROM users WHERE username = ${username}`;
    
    if (result.recordset.length === 0) {
      return res.status(401).json({ message: 'Invalid username or password' });
    }

    const user = result.recordset[0];

    // Validate password
    const isValidPassword = await bcrypt.compare(password, user.password);
    
    if (!isValidPassword) {
      return res.status(401).json({ message: 'Invalid username or password' });
    }

    // Generate JWT
    const token = jwt.sign({ id: user.id, username: user.username }, JWT_SECRET, { expiresIn: '1h' });

    return res.status(200).json({ token });
  } catch (error) {
    console.error('Database error:', error);
    return res.status(500).json({ message: 'Internal server error' });
  } finally {
    // Close the database connection
    await sql.close();
  }
});

// Start the server
app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
```

### Configuration

1. **Database Credentials**: Replace the placeholders in `dbConfig` with your actual SQL Server database credentials.

2. **JWT Secret**: Ensure to set a strong secret for JWT generation.

### Running the API

1. **Start the server**:

   ```bash
   node server.js
   ```

2. **Test the API**:

   Use Postman or curl to make a POST request to `http://localhost:3000/login` with a JSON body:

   ```json
   {
     "username": "your_username",
     "password": "your_password"
   }
   ```

   If the login is successful, you will receive a JWT token in response:

   ```json
   {
     "token": "your_generated_jwt_token"
   }
   ```

### Notes

- **Error Handling**: This example includes basic error handling. You may want to enhance this further for production use.
- **Security**: Use HTTPS for your API in production to ensure secure transmission of credentials.
- **Password Hashing**: Ensure that the passwords in your database are hashed (use `bcrypt` for hashing).

Feel free to modify this code to better fit your specific requirements!
