document.addEventListener("DOMContentLoaded", () => {
    slideBlackWhite()
})

function slideBlackWhite() {
    var slider = document.getElementById("slider-bw");
    var lightImage = document.querySelector('.light-image');
    var darkImage = document.querySelector('.dark-image');
    var background = document.querySelector('.background');
    var btext = document.querySelector('.b-text')
    var wtext = document.querySelector('.w-text')
    var isDragging = false;

    slider.addEventListener("mousedown", function (event) {
        isDragging = true;
        background.style.width = 100 + "%";
    });

    document.addEventListener("mousemove", function (event) {
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

    slider.addEventListener("mouseup", function (event) {
        isDragging = false;
    });
}