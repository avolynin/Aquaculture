const REQUIRED_FIELD = "Поле обязательно для ввода"

export const emailValidation={
    required: REQUIRED_FIELD,
    validate: (value: String) => {
        
        if(value.match(/[а-яА-Я]/)){
            return "Email не должен содержать русских букв";
        }

        return true;
    }
}

export const passwordValidation={
    required: REQUIRED_FIELD
}