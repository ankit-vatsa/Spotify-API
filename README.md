# Spotify-API in SIMPLIFIED MANNER

<h2>Get Access Token</h2>

- Curl
```
curl -X POST "https://accounts.spotify.com/api/token" -H "Content-Type: application/x-www-form-urlencoded" -d "grant_type=client_credentials&client_id=your-client-id&client_secret=your-client-secret"
```
- Chrome Console
```
const client_id = 'your_client_id'; 
const client_secret = 'your_client_secret'; 

// Use btoa() for Base64 encoding in the browser
const authHeader = 'Basic ' + btoa(client_id + ':' + client_secret);

// Define the request body
const data = new URLSearchParams();
data.append('grant_type', 'client_credentials');

// Send the request to get the token using fetch API
fetch('https://accounts.spotify.com/api/token', {
  method: 'POST',
  headers: {
    'Authorization': authHeader,
    'Content-Type': 'application/x-www-form-urlencoded',
  },
  body: data,
})
  .then(response => response.json())
  .then(data => {
    const token = data.access_token;
    console.log('Access token:', token);
    // You can now use this token for further API calls
  })
  .catch(error => {
    console.error('Error getting access token:', error);
  });

```
