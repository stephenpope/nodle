exports.init = function(app, publicPath){
    //properties
    var title = "Node{msg}";
	//index
	app.get('/', function(req, res){

		res.render('index', {
			title: title,
            crumbs: [
                {name:"Home", url:"#"},
                {name:"Filter A", url:"#filterA"},
                {name:"Filter B", url:"#filterA/filterB"},
                {name:"Filter C", url:"#filter/filterB/filterC"}
            ],
            current: "Filter D"

		})
	});
	
	//chat
	app.get('/chat', function(req, res){
		res.sendfile(publicPath + '/chat.htm');
	});
	
	app.get('/panels/:name', function(req, res){
		var content = [];
		for(var x = 0; x < 6; x++){
			content.push(req.params.name + x);
		}
		res.json({children:content});
	});
}