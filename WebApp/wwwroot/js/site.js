
try {
    const toggleBtn = document.querySelector('[data-option="toggle"]')
    toggleBtn.addEventListener('click', function () {
        const element = document.querySelector(toggleBtn.getAttribute('data-target'))

        if (!element.classList.contains('hide')) {
            element.classList.add('hide')
        } else {
            element.classList.remove('hide')
        }
    })
} catch { }

