function editNews() {
    let element = $(this).parent().parent();
    let date = $(element).find('#date').text();
    let description = $(element).find('#description').text();
    let content = $(element).find('#content').text();
    let id = $(element).find('#id').text();
    $('#form').find('#date').val(date);
    $('#form').find('#description').val(description);
    $('#form').find('#id').val(id);
    CKEDITOR.instances['content-editor'].setData(content);
}

function removeNews() {
    let id = $(this).parent().parent().find('#id').text();
    $.get('DeleteNews', { id: id });
    $(this).parent().parent().remove();
}

function saveContent() {
    let content = CKEDITOR.instances['content-editor'].getData();
    content = content.replace(/<\/?[a-zA-Z]+>/gi, '');
    $('#form').find('#content').text(content);
}

function editCategory() {
    let element = $(this).parent().parent();
    let category = $(element).find('#category').text();
    let id = $(element).find('#id').text();
    $('#form').find('#category').val(category);
    $('#form').find('#id').val(id);
}

function removeCategory() {
    let id = $(this).parent().parent().find('#id').text();
    $.get('DeleteCategory', { id: id });
    $(this).parent().parent().remove();
}

function editMenu() {
    let element = $(this).parent().parent();
    let name = $(element).find('#name').text();
    let cost = $(element).find('#cost').text();
    let category = $(element).find('#category').text();
    let id = $(element).find('#id').text();
    $('#form').find('#name').val(name);
    $('#form').find('#cost').val(cost);
    $('#form').find('#category').val(category);
    $('#form').find('#id').val(id);
}

function removeMenu() {
    let id = $(this).parent().parent().find('#id').text();
    $.get('DeleteProduct', { id: id });
    $(this).parent().parent().remove();
}

function editRestaurant() {
    let element = $(this).parent().parent();
    let name = $(element).find('#name').text();
    let address = $(element).find('#address').text();
    let id = $(element).find('#id').text();
    $('#form').find('#name').val(name);
    $('#form').find('#address').val(address);
    $('#form').find('#id').val(id);
}

function removeRestaurant() {
    let id = $(this).parent().parent().find('#id').text();
    $.get('DeleteRestaurant', { id: id });
    $(this).parent().parent().remove();
}

function removeReview() {
    let id = $(this).parent().parent().find('#id').text();
    $.get('DeleteReview', { id: id });
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
    let id = $(element).find('#id').text();
    $('#form').find('#date').val(date);
    $('#form').find('#restaurant').val(restaurant);
    $('#form').find('#fio').val(fio);
    $('#form').find('#guests').val(guests);
    $('#form').find('#phone').val(phone);
    $('#form').find('#id').val(id);
    CKEDITOR.instances['content-editor'].setData(content);
}

function removeTableOrder() {
    let id = $(this).parent().parent().find('#id').text();
    $.get('DeleteOrder', { id: id });
    $(this).parent().parent().remove();
}

function addProductItem(id, img, title, cost) {
    let newTr = document.createElement("tr");
    $(newTr).html(
        '<td id="product-img">'+
            '<img src="'+img+'" alt=""></td>'+
        '<td id="product-title">'+title+'</td>'+
        '<td class="product-cost" id="product-cost">'+cost+'</td>' +
        '<td class="product-id hide" id="product-id">'+
            '<input type="hidden" name="OrderedProducts" value="' + id + '">' +
        '</td>' +
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
    let id = $(element).find('#id').text();
    let product_images = [], product_titles = [], product_costs = [], product_id = [];
    $(element).find("img").each(function(i, elem) {
        product_images[i] = $(elem).attr('src');
    });
    $(element).find(".product-title").each(function(i, elem) {
        product_titles[i] = $(elem).text();
    });
    $(element).find(".product-cost").each(function(i, elem) {
        product_costs[i] = $(elem).text();
    });
    $(element).find(".product-id").each(function (i, elem) {
        product_id[i] = $(elem).text();
    });
    for(let i = 0; i < product_titles.length; i++) {
        addProductItem(product_id[i], product_images[i], product_titles[i], product_costs[i]);
    }
    $('#form').find('#date').val(date);
    $('#form').find('#restaurant').val(restaurant);
    $('#form').find('#fio').val(fio);
    $('#form').find('#guests').val(guests);
    $('#form').find('#phone').val(phone);
    $('#form').find('#id').val(id);
    CKEDITOR.instances['content-editor'].setData(content);
    costCalculation();
}

function removeEventOrder() {
    let id = $(this).parent().parent().find('#id').text();
    $.get('DeleteOrder', { id: id });
    $(this).parent().parent().remove();
}

function addProductOrder() {
    let element = $(this).parent().parent();
    let img = $(element).find("img").attr('src');
    let title = $(element).find("#product-title").text();
    let cost = $(element).find("#product-cost").text();
    let id = $(element).find("#product-id").text();
    addProductItem(id, img, title, cost);
}

function removeProductOrder() {
    let element = $(this).parent().parent();
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