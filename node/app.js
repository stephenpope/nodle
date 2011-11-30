
/**
 * Module dependencies.
 */    
      
var express = require('express'),
	app = module.exports = express.createServer(),
	routeConfig = require('./core/routes').init(app, __dirname + '/public'),
	socketConfig = require('./core/socket').init(app);

// Configuration
app.configure(function(){
  app.set('views', __dirname + '/views'); 
  app.set('view engine', 'jade');
  app.use(express.bodyParser());
  app.use(express.methodOverride());
  app.use(express.static(__dirname + '/public'));
  app.use(app.router);  
});

app.configure('development', function(){
  app.use(express.errorHandler({ dumpExceptions: true, showStack: true })); 
});

app.configure('production', function(){
  app.use(express.errorHandler()); 
});
       
app.listen(process.env.PORT);
console.log("Express server listening in %s mode", app.settings.env);

