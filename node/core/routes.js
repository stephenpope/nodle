/*
    Route configuration
 */
exports.init = function(app, nano, io, publicPath) {
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
        var id = req.header('nodleMsgId');
        var channel = req.params.channel;
        var content = req.body;
        
        console.log(req.is('json'));
        console.log(req);
        //store message
        nano.store(channel, id, content, function(data){
            res.json({
                id: id,
                channel: channel,
                content: data
            })
        });

        io.send(content, function(){
            console.log('sent');
        });
        //distribute message
    })

    app.get('/channels', function(req, res){
        res.json(nano.channels);
    })
};