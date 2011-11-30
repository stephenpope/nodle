$(function(){
    //load up the connections from local storage
    function loadConnections(){
        var connections = settings.connections || [];
        if(connections.length){
            var template = '{{#rows}}<tr><td>{{name}}</td><td>{{url}}</td><td><input type="checkbox"/></td></tr>{{/rows}}';
            var html = Mustache.to_html(template, {rows: connections});
            $('#connections-table-body').html(html);
        }
    }

    //clear the new connection form details
    function clearConnection(){
         $('#connection-name').val('');
         $('#connection-url').val('');
         $('#connect-on-create').removeAttr('checked');
    }

    $('#manage-connections').modal({
        keyboard: true,
        backdrop: true
    }).find('.btn.primary').click(function(){
            //TODO: Add error checking for fields
        var connect = $('#connect-on-create').is(':checked');
        var name = $('#connection-name').val();
        var connections = settings.connections || [];
        connections.push({
            name: name,
            url: $('#connection-url').val()
        });
        settings.connections = connections;
        $('#message-name').text(name);
        $('#create-connection-message').fadeIn(500).delay(1000).fadeOut(500);
        clearConnection();
    }).next().click(clearConnection);

    loadConnections();

    ////create a new filter
    $('#filter-create').click(function(){
        var item = '<li><a href="#about">Filter B</a><span class="delete"></span></li>';
        $('#saved-filters').append($(item));
    });

    //wire delete search buttons
    $('#saved-filters').on('click', 'span', function(){
        $(this).twipsy('hide').parent().fadeOut(800);
    });

    $('#saved-filters span').twipsy({
        placement: 'right',
        live: true,
        title: function(){
            return 'Delete ' + $(this).prev().text();
        }
    });

    $('#saved-filters a').popover({
        live: true,
        title: function(){
            return $(this).text();
        },
        content: function(){
            return $(this).attr('href');
        },
        offset: 5,
        delayIn: 500
    });
  
    $('#filter-help').popover({
        title: function(){
            return "Filter Help"
        },
        html: true,
        content: function(){
            return "Create filters to focus on the messages you want to see."
                +"<br /><br />"
            + "Export filters for use on other messaging instances"
        }
    });

    $('#options-help').popover({
        title: function(){
            return "Options Help"
        },
        html: true,
        content: function(){
            return "Max messages determines how many messages are visible in the window (max 1000)."
                +"<br /><br />"
            + "Using the export options you can save details of the current view locally"
        }
    });

    $('#users-help').popover({
        title: function(){
            return "Users Help"
        },
        content: function(){
            return "See who is currently connected to the service and send messages."
        }
    });
});