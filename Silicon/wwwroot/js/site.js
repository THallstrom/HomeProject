document.addEventListener("DOMContentLoaded", () => {
    hamburger()
    select()
    circle()
    handleImgUploader()
    active()
    textSearch()
    slideBlackWhite()
    darkmode()
})

function slideBlackWhite() {
    var slider = document.getElementById("slider-bw");
    var lightImage = document.querySelector('.light-image');
    var darkImage = document.querySelector('.dark-image');
    var background = document.querySelector('.background');
    var btext = document.querySelector('.b-text')
    var wtext = document.querySelector('.w-text')
    var isDragging = false;

    slider.addEventListener("mousedown", function(event) {
        isDragging = true;
        background.style.width=100 + "%";
    });
        
    document.addEventListener("mousemove", function(event) {
        if (isDragging) {
            var x = event.clientX - darkImage.getBoundingClientRect().left;
            var containerWidth = darkImage.offsetWidth;
                
            x = Math.max(0, Math.min(x, containerWidth));
                
            slider.style.left = x + "px";
            var ratio = x / containerWidth;
            var inverseRatio = 1 - ratio;
                
            darkImage.style.clipPath = "inset(0 " + inverseRatio * 100 + "% 0 0)";
            lightImage.style.clipPath = "inset(0 0 0 " + ratio * 100 + "%)";
            background.style.clipPath = "inset(0 " + inverseRatio * 100 + "% 0 0)";
            wtext.style.clipPath = "inset(0 " + inverseRatio * 100 + "% 0 0)";
            btext.style.clipPath = "inset(0 0 0 " + ratio * 100 + "%)";
        }
    });
    
    slider.addEventListener("mouseup", function(event) {
        isDragging = false;
    });
}


function hamburger() {
    try {

        let btnMenu = document.querySelector('.btn-menu')
        let nav = document.querySelector('nav')
        let accBtn = document.querySelector('.account-buttons')


        btnMenu.addEventListener('click', () => {
            btnMenu.classList.toggle('active')
            btnMenu.classList.toggle('fixed')
            nav.classList.toggle('active')
            accBtn.classList.toggle('active')
        })

        window.addEventListener('resize', () => {
            btnMenu.classList.remove('active')
            btnMenu.classList.remove('fixed')
            nav.classList.remove('active')
            accBtn.classList.remove('active')
        })
    } catch { }
}
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
    try {

        const searchValue = "";
        const url = `/course/Courses?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchValue)}`
        fetch(url)
            .then(res => res.text())
            .then(data => {
                const parser = new DOMParser()
                const dom = parser.parseFromString(data, 'text/html')
                document.querySelector('.course-expose-area').innerHTML = dom.querySelector('.course-expose-area').innerHTML

                const pagination = dom.querySelector('.pagination') ? dom.querySelector('.pagination').innerHTML : ''
                document.querySelector('.pagination').innerHTML = pagination
            })
    } catch { }
}

function textSearch() {   
    try {

        document.querySelector('#searchQuary').addEventListener('keyup', function () {
            const searchValue = this.value
            const category = ""
            const url = `/course/Courses?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchValue)}`

            fetch(url)
                .then(res => res.text())
                .then(data => {
                    const parser = new DOMParser()
                    const dom = parser.parseFromString(data, 'text/html')
                    document.querySelector('.course-expose-area').innerHTML = dom.querySelector('.course-expose-area').innerHTML

                    const pagination = dom.querySelector('.pagination') ? dom.querySelector('.pagination').innerHTML : ''
                    document.querySelector('.pagination').innerHTML = pagination
                })
        })
    } catch { }
}

function circle() {
    try {
        let circles = document.querySelectorAll('.circle');
        circles.forEach(function (circle) {
            circle.addEventListener('click', function () {
                circle.classList.toggle('clicked');
            });
        });
    } catch { }
}

function handleImgUploader() {
    try {
        let uploader = document.querySelector('#fileUpLoader');
        if (uploader != undefined) {
            uploader.addEventListener("change", function () {
                if (this.files.length > 0) {
                    this.form.submit()
                }
            })
        }
    } catch { }
}

function active() {
    document.querySelectorAll('.link-btn').forEach(link => {
        if (link.href === window.location.href) {
            link.classList.add('btn-theme');
            link.classList.remove('btn-secundary');
        } else {
            link.classList.remove('btn-theme');
            link.classList.add('btn-secundary');
        }
    });   
}

function darkmode() {
    try {
        let themeSwitch = document.querySelector("#theme-switch-mode");

        themeSwitch.addEventListener("change", function () {
            let mode = this.checked ? "dark" : "light";
            fetch(`/sitesettings/theme?mode=${mode}`).then((res) => {
                if (res.ok) window.location.reload();
                else console.log("unable to switch to theme mode");
            });
        });
    } catch { }
}