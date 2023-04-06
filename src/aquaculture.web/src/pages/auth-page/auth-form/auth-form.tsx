import { TextField, Typography } from "@mui/material";
import Button from "@mui/material/Button";
import { useForm, Controller, SubmitHandler, useFormState } from "react-hook-form";
import './auth-form.css';
import { emailValidation, passwordValidation, usernameValidation } from "./validation";

interface ISignInForm{
    email: string;
    username: string;
    password: string;
}

const AuthForm = () => {
    const { handleSubmit, control } = useForm<ISignInForm>();
    const {errors} = useFormState({control});
    const onSubmit: SubmitHandler<ISignInForm> = data => registerUser(data);

    const registerUser = async (data: ISignInForm) => {
        const response = await fetch(
            'api/auth/register',
            {
                method: "post",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    "FullName": data.username,
                    "email": data.email,
                    "password": data.password
                })
            }
        )

        var responseJson = response.json();
        console.log(responseJson);
    }

    return(
        <div className="auth-form">
            <Typography variant="h1" component="div" gutterBottom={true}>
                 Log in
            </Typography>
            <form className="auth-form__form" onSubmit={handleSubmit(onSubmit)}>
                <Controller
                    control={control}
                    name="email"
                    rules={emailValidation}
                    render={({field}) => (
                        <TextField
                            label="Email"
                            size="small"
                            margin="normal"
                            className="auth-form__input"
                            fullWidth={true}
                            onChange={(e) => field.onChange(e)}
                            value ={field.value || ""}
                            error={!!errors.email?.message}
                            helperText={errors.email?.message}
                        />
                    )}
                />
                <Controller
                    control={control}
                    name="username"
                    rules={usernameValidation}
                    render={({field}) => (
                        <TextField
                            label="Username"
                            type="username"
                            size="small"
                            margin="normal"
                            className="auth-form__input"
                            fullWidth={true}
                            onChange={(e) => field.onChange(e)}
                            value ={field.value || ""}
                            error={!!errors.username?.message}
                            helperText={errors.username?.message}
                        />
                    )}
                />
                <Controller
                    control={control}
                    name="password"
                    rules={passwordValidation}
                    render={({field}) => (
                        <TextField
                            label="Password"
                            type="password"
                            size="small"
                            margin="normal"
                            className="auth-form__input"
                            fullWidth={true}
                            onChange={(e) => field.onChange(e)}
                            value ={field.value || ""}
                            error={!!errors.password?.message}
                            helperText={errors.password?.message}
                        />
                    )}
                />
                <Button
                    type="submit"
                    variant="contained"
                    fullWidth={true}
                    disableElevation={true}
                    sx={{
                        marginTop: 2
                    }}
                >
                    Enter
                </Button>
            </form>
        </div>
    );
};

export default AuthForm;