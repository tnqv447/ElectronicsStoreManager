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
        if(username==null || username == "" || pw == null || pw==""){
            $('#err_login').text('Username and password not empty');
            $('#err_login').css("display","block");
        } // m làm model r thì t làm model bth thôi
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
                // đợi t suy nghĩ chút ok
                success: function(result){
                    if(result.Message != null){
                        $('#err_login').text(result.Message);
                        $('#err_login').css("display","block");
                    }
                    else{
                        $('#partial').html(result);
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