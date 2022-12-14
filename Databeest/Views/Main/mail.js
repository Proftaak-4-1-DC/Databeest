// Show selected type of inbox like Inbox or Sent 
function showLeft(id) {
    $('#' + id).show();
    $('.inbox-hide').not('#' + id).hide();

    if (id == 'b1') {
        $('.inbox').removeClass('selected');
        $('#box-start1').addClass('selected');
        $('#' + 'i1').show();
        $('.mailbox-container').not('#' + 'i1').hide();
        
    }
    if (id == 'b2') {
        $('.inbox').removeClass('selected');
        $('#box-start2').addClass('selected');
        $('#' + 'i7').show();
        $('.mailbox-container').not('#' + 'i7').hide();  
    }
}

// Open selected mail on right side function
    function MailOpen(id) {
        $('#' + id).show();
        $('.mailbox-container').not('#' + id).hide();
        $(this).addClass('selected');
        }

        $(function(){
            $('.inbox').click(function(){
                $('.inbox').removeClass('selected');
                $(this).addClass('selected');
            });
        });
        

        // Search bar filter function 
        $(document).ready(function(){
            $("#search-bar").on("keyup", function() {
                var value = $(this).val().toLowerCase();
                $("#b1 .inbox").filter(function() {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });

        $(document).ready(function(){
            $("#search-bar").on("keyup", function() {
                var value = $(this).val().toLowerCase();
                $("#b2 .inbox").filter(function() {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });