function editNews() {
    let element = $(this).parent().parent();
    let date = $(element).find('#date').text();
    let description = $(element).find('#description').text();
    let content = $(element).find('#content').text();
    $('#form').find('#date').val(date);
    $('#form').find('#description').val(description);
    CKEDITOR.instances['content'].setData(content);
}

function removeNews() {
    $(this).parent().parent().remove();
}

function editCategory() {
    let element = $(this).parent().parent();
    let category = $(element).find('#category').text();
    $('#form').find('#category').val(category);
}

function removeCategory() {
    $(this).parent().parent().remove();
}

function editMenu() {
    let element = $(this).parent().parent();
    let name = $(element).find('#name').text();
    let cost = $(element).find('#cost').text();
    let category = $(element).find('#category').text();
    $('#form').find('#name').val(name);
    $('#form').find('#cost').val(cost);
    $('#form').find('#category').val(category);
}

function removeMenu() {
    $(this).parent().parent().remove();
}

function editRestaurant() {
    let element = $(this).parent().parent();
    let name = $(element).find('#name').text();
    let address = $(element).find('#address').text();
    $('#form').find('#name').val(name);
    $('#form').find('#address').val(address);
}

function removeRestaurant() {
    $(this).parent().parent().remove();
}

function removeReview() {
    $(this).parent().parent().remove();
}

function editTableOrder() {
    let element = $(this).parent().parent();
    let date = $(element).find('#date').text();
    let restaurant = $(element).find('#restaurant').text();
    let fio = $(element).find('#fio').text();
    let guests = $(element).find('#guests').text();
    let phone = $(element).find('#phone').text();
    let content = $(element).find('#content').text();
    $('#form').find('#date').val(date);
    $('#form').find('#restaurant').val(restaurant);
    $('#form').find('#fio').val(fio);
    $('#form').find('#guests').val(guests);
    $('#form').find('#phone').val(phone);
    CKEDITOR.instances['content'].setData(content);
}

function removeTableOrder() {
    $(this).parent().parent().remove();
}

function addProductItem(img, title, cost) {
    let newTr = document.createElement("tr");
    $(newTr).html(
        '<td id="product-img">'+
            '<img src="'+img+'" alt="">'+
            '<input type="hidden" name="product-img" value="'+img+'">'+
        '</td>'+
        '<td id="product-title">'+title+
            '<input type="hidden" name="product-title" value="'+title+'">'+
        '</td>'+
        '<td class="product-cost" id="product-cost">'+cost+
            '<input type="hidden" name="product-cost" value="'+cost+'">'+
        '</td>'+
        '<td><a onclick="removeProductOrder.call(this)">Удалить</a></td>'
    );
    $('#product-list').find('tbody').append(newTr);
    costCalculation();
}

function editEventOrder() {
    $('#product-list tbody').find('tr').each(function(i, elem) {
        $(elem).remove();
    });
    let element = $(this).parent().parent();
    let date = $(element).find('#date').text();
    let restaurant = $(element).find('#restaurant').text();
    let fio = $(element).find('#fio').text();
    let guests = $(element).find('#guests').text();
    let phone = $(element).find('#phone').text();
    let content = $(element).find('#content').text();
    let product_images = [], product_titles = [], product_costs = [];
    $(element).find("img").each(function(i, elem) {
        product_images[i] = $(elem).attr('src');
    });
    $(element).find(".product-title").each(function(i, elem) {
        product_titles[i] = $(elem).text();
    });
    $(element).find(".product-cost").each(function(i, elem) {
        product_costs[i] = $(elem).text();
    });
    for(let i = 0; i < product_titles.length; i++) {
        addProductItem(product_images[i], product_titles[i], product_costs[i]);
    }
    $('#form').find('#date').val(date);
    $('#form').find('#restaurant').val(restaurant);
    $('#form').find('#fio').val(fio);
    $('#form').find('#guests').val(guests);
    $('#form').find('#phone').val(phone);
    CKEDITOR.instances['content'].setData(content);
    costCalculation()
}

function removeEventOrder() {
    $(this).parent().parent().remove();
}

function addProductOrder() {
    let element = $(this).parent().parent();
    let img = $(element).find("img").attr('src');
    let title = $(element).find("#product-title").text();
    let cost = $(element).find("#product-cost").text();
    addProductItem(img, title, cost);
    $(element).remove();
}

function removeProductOrder() {
    let element = $(this).parent().parent();
    let img = $(element).find("img").attr('src');
    let title = $(element).find("#product-title").text();
    let cost = $(element).find("#product-cost").text();
    let newTr = document.createElement("tr");
    $(newTr).html(
        '<td id="product-img">'+'<img src="'+img+'" alt="">'+'</td>'+
        '<td id="product-title">'+title+'</td>'+
        '<td id="product-cost">'+cost+'</td>'+
        '<td><a onclick="addProductOrder.call(this)">Добавить</a></td>'
    );
    $('#hide-list').find('table').append(newTr);
    $(element).remove();
    costCalculation();
}

function showListProducts() {
    $('#show-list-products').remove();
    let a = document.createElement("a");
    $(a).addClass("button");
    $(a).attr('id','close-list-products');
    $(a).attr('onclick','hideListProducts()');
    $(a).text('Закрыть список');
    $('#hide-list').before(a);
    $('.hide-list').show();
}

function hideListProducts() {
    $('#close-list-products').remove();
    let a = document.createElement("a");
    $(a).addClass("button");
    $(a).attr('id','show-list-products');
    $(a).attr('onclick','showListProducts()');
    $(a).text('Добавить блюдо');
    $('#hide-list').before(a);
    $('.hide-list').hide();
}

function costCalculation() {
    let numberGuests = $("#guests").val();
    if(numberGuests == 0 || numberGuests == null) {
        numberGuests = 1;
    }

    let costProducts = 0;
    $('#product-list').find('.product-cost').map(function(i, element) {
        costProducts = costProducts + Number($(element).text());
    });

    let costEvent = costProducts * numberGuests;
    $("#cost").val(costEvent);
}