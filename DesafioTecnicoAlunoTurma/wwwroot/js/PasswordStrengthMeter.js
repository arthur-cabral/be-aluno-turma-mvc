var shortPass = 'Muito Curta'
var badPass = 'Ruim'
var goodPass = 'Boa'
var strongPass = 'Forte'
function passwordStrength(password, username) {
    placar = 0
    //password < 4
    if (password.length < 4) { return shortPass }
    //password == username
    if (password.toLowerCase() == username.toLowerCase()) return badPass
    //tamanho da senha
    placar += password.length * 4
    placar += (verificarRepeticao(1, password).length - password.length) * 1
    placar += (verificarRepeticao(2, password).length - password.length) * 1
    placar += (verificarRepeticao(3, password).length - password.length) * 1
    placar += (verificarRepeticao(4, password).length - password.length) * 1
    //senha tem 3 numeros
    if (password.match(/(.*[0-9].*[0-9].*[0-9])/)) placar += 5
    //senha tem dois simbolos
    if (password.match(/(.*[!,@,#,$,%,^,&,*,?,_,~].*[!,@,#,$,%,^,&,*,?,_,~])/)) placar += 5
    //senha tem caracteres maiusculos e minusculos
    if (password.match(/([a-z].*[A-Z])|([A-Z].*[a-z])/)) placar += 10
    //senha tem numeros e caracteres
    if (password.match(/([a-zA-Z])/) && password.match(/([0-9])/)) placar += 15
    //
    //senha tem numeros e símbolos
    if (password.match(/([!,@,#,$,%,^,&,*,?,_,~])/) && password.match(/([0-9])/)) placar += 15
    //senha tem caractere e símbolo
    if (password.match(/([!,@,#,$,%,^,&,*,?,_,~])/) && password.match(/([a-zA-Z])/)) placar += 15
    //senha tem apenas numeros ou caracteres
    if (password.match(/^\w+$/) || password.match(/^\d+$/)) placar -= 10
    // vreificando o placar entre :  0 < placar < 100
    if (placar < 0) placar = 0
    if (placar > 100) placar = 100
    if (placar < 34) return badPass
    if (placar < 68) return goodPass
    return strongPass
}
// verificarRepeticao(1,'aaaaaaabcbc')   = 'abcbc'
// verificarRepeticao(2,'aaaaaaabcbc')   = 'aabc'
// verificarRepeticao(2,'aaaaaaabcdbcd') = 'aabcd'
function verificarRepeticao(pLen, str) {
    res = ""
    for (i = 0; i < str.length; i++) {
        repeated = true
        for (j = 0; j < pLen && (j + i + pLen) < str.length; j++)
            repeated = repeated && (str.charAt(j + i) == str.charAt(j + i + pLen))
        if (j < pLen) repeated = false
        if (repeated) {
            i += pLen - 1
            repeated = false
        }
        else {
            res += str.charAt(i)
        }
    }
    return res
}