const express = require('express');
const exphbs = require('express-handlebars');
const bodyParser = require('body-parser');
const flash = require('express-flash');
const session = require('express-session');

const app = express();

app.use(session({
    secret: 'this is my long String that is used for session in http',
    resave: false,
    saveUninitialized: true,
  }));
  
  app.engine('handlebars', exphbs({ defaultLayout: 'main' }));
  app.set('view engine', 'handlebars');
  // initialise the flash middleware
  app.use(flash());
  // parse application/x-www-form-urlencoded
  app.use(bodyParser.urlencoded({ extended: false }));
  // parse application/jsongreetInstance
  app.use(bodyParser.json());
  app.use(express.static('public'));

  app.get('/', waiterRoute.defaultRoute);