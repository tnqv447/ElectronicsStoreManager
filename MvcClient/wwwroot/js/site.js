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
                        $('#partial').load(location.href + ' #partial');
                    }
                },
                complete: function(){
                    
                },
                error: function(){
                   
                }
            })
        }
        
    })
    $(document).on('click','.addCart',function(){
        var url = $('#addToCart').val();
        var id = $(this).attr('id');
        var name = $('#name_'+id).text();
        var price = $('#price_' +id).val();
        var type = $('#type_' + id).val();
        $.ajax({
            type:'POST',
            url: url,
            data:{
                item:{
                    Id:id,
                    Price:price,
                    Name:name,
                    Type:type
                },
                Quantity: 1
            },
            success:function(data){
                $('#totalPrice').text('$'+data.TotalPrice);
                $('#totalItem').text(data.TotalItem);
                alert('Add to cart successfully');
            },
            error:function(){
                alert("Add to cart failed");
            }
        })
    })
    $(document).on('click','.value-minus,.value-plus,.close1',function(){
        var temp = $(this).attr('id');
        var id = temp.slice(6);
        var action = temp.slice(0,5);
        UpdateCart(action,id);
    })
    function UpdateCart(action,ItemId){
        var url = $('#UrlUpdateCart').val();
        $.ajax({
            type:'POST',
            url:'/Cart/UpdateCart',
            data:{
                action:action,
                ItemId:ItemId
            },
            success: function(data){
                $("#partial").html(data);
            },
            
        })
    }
    $(document).on('click','#navigate',function(){
        $.ajax({
            type:"GET",
            url:'/Cart/GetInfor',
            success:function(data){
                $('#partial').html(data);
            },
            complete:function(){
                $(this).css('display','none');
            }
        })
    })
});