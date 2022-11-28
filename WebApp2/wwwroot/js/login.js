function btnLogin() {
        let result = new Object();
        result.Email = $("input[name='emailLog']").val();
        result.Password = $("input[name='passLog']").val();
        console.log(result.Email);
        console.log(result.Password);
        //let DivId = $('departId')

        var resultt = result;
        $.ajax({
            url: `https://localhost:7240/api/Login/Login`,
            method: 'POST',
            data: JSON.stringify(resultt),
            dataType: 'text',
            headers: {
                 'content-Type': 'application/json'
            },
            success: function (d) {
                console.log(d);
                sessionStorage.setItem("token", d.token);
                console.log(d.token);
                window.location.replace("../department/index")
                //if (data.Message == "Login gagal") {
                //    Swal.fire('Error!', `${data.Message}`, 'error')
                //} else {
                //    //Swal.fire('Done!', `${data.Message}`, 'success')
                //    console.log(data.Token);
                //    //console.log("hahahahah");

                //}
            }
        })
}

//function pindah() {
//            window.location.replace("../department/index")
//}
