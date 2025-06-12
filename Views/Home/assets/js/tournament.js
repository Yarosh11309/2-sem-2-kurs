(function(){
    function load(){
        let list = JSON.parse(localStorage.getItem('tournaments')||'null');
        if(!list){
            list = [];
            $('#tournamentList .single-tournament-2').each(function(){
                const name = $(this).find('h4').text();
                const image = $(this).find('img.main-img').attr('src');
                const prize = $(this).find('.color-base').text().trim();
                list.push({name,image,prize});
            });
            save(list);
        }
        return list;
    }
    function save(list){ localStorage.setItem('tournaments', JSON.stringify(list)); }
    function render(){
        const list = load();
        const c = $('#tournamentList').empty();
        list.forEach((t,i)=>{
            c.append(`<div class="col-lg-6 fade-slide bottom"><div class="single-tournament-2"><img class="bg-img" src="assets/img/tournament/bg-3.png" alt="img"><div class="content-area"><div class="top-area d-flex align-items-center align-self-center"><img class="me-3 main-img" src="${t.image}" alt="img"><div class="details"><h6>Action</h6><h4 class="mb-0">${t.name}</h4></div></div><span class="line-shadow"></span><div class="bottom-area"><div class="row"><div class="col-4"><span>PRIZE</span><br><span class="color-base">${t.prize}</span></div><div class="col-4"></div><div class="col-4 text-end">${auth.isAdmin()?`<button class='btn btn-danger btn-sm' data-index='${i}'>Удалить</button>`:''}</div></div></div></div></div>`);
        });
    }
    $(document).on('submit','#addTournamentForm',function(e){
        e.preventDefault();
        const list = load();
        list.push({name:$('#tourName').val(), prize:$('#tourPrize').val(), image:$('#tourImage').val()});
        save(list); render(); this.reset();
    });
    $(document).on('click','#tournamentList .btn-danger',function(){
        const i=$(this).data('index');
        const list = load();
        list.splice(i,1); save(list); render();
    });
    $(function(){
        if(auth.isAdmin()) $('#addTournamentForm').show();
        render();
    });
})();
