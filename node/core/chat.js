//socket.io handling
var config = function(io){
	io.sockets.on('connection', function(client){
		
		//login inform others of connection
		client.on('login', function(name, callback){
			client.set('details', {name: name}, function(){
				callback('Welcome ' + name); 
				client.send(io.sockets.clients().length + ' people in chat');
				client.broadcast.send('Joined chat: ' + name);
			});
		});
		
		//given data, pass to all other connections
		client.on('message', function(data){
			client.get('details', function(err, details){
					io.sockets.send(details.name + ': ' + data);
			})		
		});
	});
};

exports.config = config;
