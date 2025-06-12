(function(){
    function load(){
        let list = JSON.parse(localStorage.getItem('products')||'[]');
        if(!list.length){
            list = [
                {name:'Baseball Cap',price:'€50.00',image:'assets/img/product/1.png'},
                {name:'Baseball Cap',price:'€50.00',image:'assets/img/product/2.png'}
            ];
            save(list);
        }
        return list;
    }
    function save(list){
        localStorage.setItem('products', JSON.stringify(list));
    }
    function render(){
        const list = load();
        const container = $('#productList').empty();
        list.forEach((p,i)=>{
            const item = $('<div class="col-lg-4 col-md-6 product-item"></div>');
            item.append(`<div class="single-product-inner text-center">
                <div class="thumb"><img src="${p.image}" alt="img"></div>
                <div class="details">
                    <h4 class="title">${p.name}</h4>
                    <h6 class="amount">${p.price}</h6>
                    <button class="btn btn-sm btn-danger" data-index="${i}">Удалить</button>
                </div>
            </div>`);
            container.append(item);
        });
        updateFilter();
    }
    function updateFilter(){
        const list = load();
        const select = $('.filter-inner-btn select');
        if(!select.length) return;
        select.empty();
        select.append('<option value="all">Все</option>');
        [...new Set(list.map(p=>p.name))].forEach(n=>{
            select.append(`<option value="${n}">${n}</option>`);
        });
    }

    $(document).on('submit','#addProductForm',function(e){
        e.preventDefault();
        const list = load();
        list.push({name:$('#productName').val(),price:$('#productPrice').val(),image:$('#productImage').val()});
        save(list); render(); this.reset();
    });
    $(document).on('click','.btn-danger',function(){
        const idx = $(this).data('index');
        const list = load();
        list.splice(idx,1); save(list); render();
    });
    $(document).on('change','.filter-inner-btn select',function(){
        const val = $(this).val();
        $('.product-item').each(function(){
            if(val==='all' || $(this).find('.title').text()===val){
                $(this).show();
            }else{ $(this).hide(); }
        });
    });
    $(render);
})();
