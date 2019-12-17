import * as Yup from "yup";

export const LoginSchema = Yup.object().shape({
    username: Yup.string()
        .required('Nome de usuário obrigatório.'),
    password: Yup.string()
        .min(6, 'Senha deve ter ao menos 6 caracteres.')
        .required('Senha obrigatória.')
})
