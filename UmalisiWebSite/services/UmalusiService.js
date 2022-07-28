'use strick'
module.exports = function () 
{
        function clientMessage(values){
             let _name = values.name;
             let _email = values.email;
             let _subject = values.subject;
             let _messaeg = values.message;

             console.log("Name "+ _name, + "\n email "+ _email+ " \n Subject "+ _subject + "\n Message \n" +_messaeg );
        }

        return{
            clientMessage,
        }
}