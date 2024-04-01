document.addEventListener("DOMContentLoaded", () => {
    let btnMenu = document.querySelector('.btn-menu')
    let nav = document.querySelector('nav')
    let accBtn = document.querySelector('.account-buttons')


    btnMenu.addEventListener('click', () => {
        btnMenu.classList.toggle('active')
        btnMenu.classList.toggle('fixed')

        nav.classList.toggle('active')

        accBtn.classList.toggle('active')
    })

    window.addEventListener('resize', ()=>{
        btnMenu.classList.remove('active')
        btnMenu.classList.remove('fixed')

        nav.classList.remove('active')

        accBtn.classList.remove('active')
    })
    select()
    circle()
})
function select() {
    try {
        let select = document.querySelector('.select')
        let selected = select.querySelector('.selected')
        let selectOptions = select.querySelector('.select-options')

        selected.addEventListener('click', function () {
            selectOptions.style.display = selectOptions.style.display === 'block' ? 'none':'block'
        })

        let options = selectOptions.querySelectorAll('.option')

        options.forEach(function (option) {
            option.addEventListener('click', function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                let category = this.getAttribute('data-value')

                updateCourseByFilter(category)
            })
        })
    }
    catch { }
}

function updateCourseByFilter(category) {
    const url = `/courses/index?category=${encodeURIComponent(category)}`

    fetch(url)
        .then(res => res.text())
        .then(data => {
            const parser = new DOMParser()
            const dom = parser.parseFromString(data, 'text/html')
            document.querySelector('.course-expose-area').innerHTML = dom.querySelector('.course-expose-area').innerHTML
        })
}

function circle() {
    let circles = document.querySelectorAll('.circle'); 
    circles.forEach(function (circle) { 
        circle.addEventListener('click', function () { 
            circle.classList.toggle('clicked');
        });
    });
}
