/*
    Route configuration
 */
exports.init = function(app, nano, io, publicPath) {
    var message = require('./models/message');
    //properties
    var title = "Nodle";

    // Get index
    app.get('/', function(req, res) {
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

    // Get panels (for demonstration of restful json)
    app.get('/panels/:name', function(req, res) {        
        var content = [];
        for (var x = 0; x < 6; x++) {
            content.push(req.params.name + x);
        }
        res.json({children:content});
    });

    app.post('/pub/:channel', function(req, res){
        var msg = message.init(req);
        var channel = req.params.channel;
        var id = req.header('nodleMsgId');
        var toRespond = !!req.header('nodleRespond');

        //store message
        nano.store(channel, id, msg, function(data){
            if(toRespond){
                res.json(data);
            }
        });

        //distribute message
        io.send(msg, function(){
            console.log('sent');
        });
    })

    app.get('/channels', function(req, res){
        res.json(nano.channels);
    })
};