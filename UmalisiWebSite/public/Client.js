document.addEventListener('DOMContentLoaded', function () {
    let errorMessageElem = document.querySelector('.error');
    let usersNameerror = document.querySelector('.usersError');
    let infoElem = document.querySelector('.info')
    
    if (infoElem.innerHTML !== '' || errorMessageElem.innerHTML !== '' || usersNameerror.innerHTML !== '') {
        setTimeout(() => {
            infoElem.innerHTML = '';
            errorMessageElem.innerHTML = ''; 
            usersNameerror.innerHTML = '';
            
        }, 3000);
    }
});