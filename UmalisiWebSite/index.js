'use strick'
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

  const UmalusiRT = require('./routes/Umalusi');
  const UmalusiService = require('./services/UmalusiService');
  
  const umalusiService = UmalusiService();
  const umalusiRoute = UmalusiRT(umalusiService);
  
  app.engine('handlebars', exphbs({ defaultLayout: 'main' }));
  app.set('view engine', 'handlebars');
  // initialise the flash middleware
  app.use(flash());
  // parse application/x-www-form-urlencoded
  app.use(bodyParser.urlencoded({ extended: false }));
  // parse application/jsongreetInstance
  app.use(bodyParser.json());
  app.use(express.static('public'));

  //pages
  app.get('/', umalusiRoute.defaultRoute);
  app.get('/about-us', umalusiRoute.aboutUs);
  app.get('/contact-us', umalusiRoute.contacts);

  //functions with pages
  app.post('/leaver-message', umalusiRoute.messages);


  const PORT = process.env.PORT || 3000;

app.listen(PORT, () => {
  // eslint-disable-next-line no-console
  console.log(`App started at port:${PORT}`);
});