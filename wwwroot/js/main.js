$(document).ready(function(){
    $('img').slideShow({
        timeOut: 5000,
        showNavigation: true,
        pauseOnHover: false,
        swipeNavigation: true
    });

    $('#dropd, .dropdown-submenu, #li-dropdown').mouseenter(function() {
        $('#myDropdown').show();
    });

    $('section, #nav').mouseenter(function() {
        $('#myDropdown').hide();
    }); 

});

function showList() {
    $('#show-product').remove();
    let a = document.createElement("a");
    $(a).addClass("button button-show-list");
    $(a).attr('id','close-product');
    $(a).attr('onclick','closeList()');
    $(a).text('Закрыть список');
    $('#hide-list').before(a);
    $('.hide-list-products').show();
}

function closeList() {
    $('#close-product').remove();
    let a = document.createElement("a");
    $(a).addClass("button button-show-list");
    $(a).attr('id','show-product');
    $(a).attr('onclick','showList()');
    $(a).text('Добавить блюдо');
    $('#hide-list').before(a);
    $('.hide-list-products').hide();
}

function addProduct() {
    let element = $(this).parent().parent();
    let img = $(element).find("img").attr('src');
    let title = $(element).find("#title").text();
    let cost = $(element).find("#cost-product-hide").text();
    let newDiv = document.createElement("div");
    $(newDiv).addClass("col-md-12 in-row");
    $(newDiv).html(
        '<div class="one-item min-product-img">'+
            '<img src="'+img+'" alt="">'+
            '<input type="hidden" name="img" value="'+img+'">'+
        '</div>'+
        '<div class="one-item product-description">'+
            '<p id="title">'+title+'</p>'+
            '<input type="hidden" name="title" value="'+title+'">'+
        '</div>'+
        '<div class="one-item text-center product-cost-min">'+
            '<p id="cost-product" class="cost-product">'+cost+'</p>'+
            '<input type="hidden" name="cost" value="'+cost+'">'+
        '</div>'+
        '<div class="one-item text-center product-remove-btn">'+
            '<a class="button-remove" id="remove-product" onclick="removeProduct.call(this)"><i class="fa fa-close"></i></a>'+
        '</div>'
    );
    $('#product-list').append(newDiv);
    $(element).remove();
    costCalculation();
}

function removeProduct() {
    let element = $(this).parent().parent();
    let img = $(element).find("img").attr('src');
    let title = $(element).find("#title").text();
    let cost = $(element).find("#cost-product").text();
    let newDiv = document.createElement("div");
    $(newDiv).addClass("col-md-12 in-row");
    $(newDiv).html(
        '<div class="one-item min-product-img">'+
            '<img src="'+img+'" alt="">'+
        '</div>'+
        '<div class="one-item product-description">'+
            '<p id="title">'+title+'</p>'+
        '</div>'+
        '<div class="one-item text-center product-cost-min">'+
            '<p id="cost-product-hide">'+cost+'</p>'+
        '</div>'+
        '<div class="one-item text-center product-remove-btn">'+
            '<a class="button-add" id="remove-product" onclick="addProduct.call(this)"><i class="fa fa-plus"></i></a>'+
        '</div>'
    );
    $('#hide-list').append(newDiv);
    $(element).remove();
    costCalculation();
}

function costCalculation() {
    let numberGuests = $("#guests").val();
    if(numberGuests == 0 || numberGuests == null) {
        numberGuests = 1;
    }
    let costProducts = 0;
    $('.cost-product').map(function(i, element) {
        costProducts = costProducts + Number($(element).text());
    });

    let costEvent = costProducts * numberGuests;
    $("#cost").val(costEvent);
}
    