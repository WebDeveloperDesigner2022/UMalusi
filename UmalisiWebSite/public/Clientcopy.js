document.addEventListener('DOMContentLoaded', function () {
    let usersNameerror = document.querySelector('.error');
        
    if (usersNameerror.innerHTML !== '') {        setTimeout(() => {
            
            usersNameerror.innerHTML = '';
            
        }, 3000);
    }
});