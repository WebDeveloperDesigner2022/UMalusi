'use strick'
module.exports = function (umalusiService) {
    function defaultRoute(req, res){
        res.render('index')
    }

    function aboutUs(req, res){
        res.render('aboutUs')
    }

    function contacts(req, res){
        res.render('Contacts')
    }

    function messages(req,res){
        let _name = req.body.name;
        let _email = req.body.email;
        let _subject = req.body.subject;
        let _messaeg = req.body.message;

        umalusiService.clientMessage({
            name: _name,
            email: _email,
            subject: _subject,
            message: _messaeg
        })
        res.render('Contacts')
    }

    return{
        defaultRoute,
        aboutUs,
        contacts,
        messages
    }
}