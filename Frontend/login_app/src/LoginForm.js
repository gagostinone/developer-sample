import React, { useState }  from "react";
import './LoginForm.css';

const LoginForm = (props) => {
	// State variables for login and password
	const [login, setLogin] = useState('');
	const [password, setPassword] = useState('');

	const handleSubmit = (event) =>{
		event.preventDefault();

		// Call the onSubmit prop with the current state values
		props.onSubmit({
			login: login,
			password: password,
		});

		// Clear the form fields
		setLogin('');
		setPassword('');
	}

	// Update state when input changes
	const handleLoginChange = (event) => {
		setLogin(event.target.value);
	}

	const handlePasswordChange = (event) => {
		setPassword(event.target.value);
	}

	return (
		//Refactored the submission to be handled with onSubmit so that we can utilize the forms properties for checking required fields
		<form className="form" onSubmit={handleSubmit}>
			<h1>Login</h1>
			<label htmlFor="name">Name</label>
			<input type="text" id="name" value={login} onChange={handleLoginChange} required/>
			<label htmlFor="password">Password</label>
			<input type="password" id="password" value={password} onChange={handlePasswordChange} required/>
			<button type="submit">Continue</button>
		</form>
	)
}

export default LoginForm;
