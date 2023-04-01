let dropdownBoxes = document.querySelectorAll('select');
let forms = document.querySelectorAll('form');

forms.forEach((e) => {
    e.addEventListener('submit', (event) => {
        event.preventDefault();
    })
})

for (var i = 0; i < dropdownBoxes.length; i++) {
    dropdownBoxes[i].addEventListener('change', (e) => {
        let selectId = '#' + e.target.id.split(" ")[1];
        let form = document.querySelector(selectId)

        form.submit();
    });
}

