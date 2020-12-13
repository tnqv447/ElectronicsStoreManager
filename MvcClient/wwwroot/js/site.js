// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function(){
    $('#formLogin').submit(function(e){
        e.preventDefault();
    })
    $(document).on('click','#loginSubmit',function(){
        var token = $('input[name="__RequestVerificationToken"]').val();
        var username = $('#userNameLogin').val();
        var pw = $('#pwLogin').val();
        if(username==null || pw == null || username.trim() == ""  || pw.trim() == ""){
            $('#err_login').text('Username and password not empty');
            $('#err_login').css("display","block");
        }
        else{
            $('#err_login').css('display','none');
            $.ajax({
                type:"POST",
                url: $(this).data('request-url'),
                data:{
                    __RequestVerificationToken: token,
                    model:{
                        Username: username,
                        Password: pw,
                        Message: ""
                    }
                },
                success: function(result){
                    if(result.Message != null){
                        $('#err_login').text(result.Message);
                        $('#err_login').css("display","block");
                    }
                    else{
                        $('#account_partial').html(result);
                        $('#loginModal').modal('hide');
                    }
                },
                complete: function(){
                    
                },
                error: function(){
                   
                }
            })
        }
        
    })
});