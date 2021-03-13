const express = require('express');
const app = express();

console.log('App is initializing...')

console.log('Initializing ejs...')
app.set('view engine', 'ejs');

console.log('Initializing public folder...')
app.use(express.static('public'));

console.log('Initializing routes...')
app.get('/', function (req, res) {
  res.render('index', {
    backendApiUrl: process.env.BACKEND_API_URL
  });
});

console.log('Starting up...')
var port = process.env.PORT || 8080;
app.listen(port, function () {
  console.log('App is listening', port);
});