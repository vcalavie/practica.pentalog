$(".subscribeButton").click(
    function () {
        if ($(this).text() == 'Subscribed')
        {
            $(this).text('Unsubscribed');
        } else {
            $(this).text('Subscribed');
            //alert("you have subscribed");
        }
    });