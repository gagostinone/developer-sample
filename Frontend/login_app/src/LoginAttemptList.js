import React, { useState } from "react";
import "./LoginAttemptList.css";

//Listed only the userName, as we should not be listing peoples passwords.
const LoginAttempt = ({ attempt }) => (
	<li>
		{attempt.login}
	</li>
);

const LoginAttemptList = ({ attempts }) => {
	//Filter logic
	const [filter, setFilter] = useState('');
	const handleFilterChange = (event) => {
		setFilter(event.target.value);
	};
	const filteredAttempts = attempts.filter(attempt =>
		attempt.login.toLowerCase().includes(filter.toLowerCase())
	);

	return (
		<div className="Attempt-List-Main">
			<p>Recent activity</p>
			<input
				type="text"
				placeholder="Filter..."
				value={filter}
				onChange={handleFilterChange}
			/>
			<ul className="Attempt-List">
				{filteredAttempts.map((attempt, index) => (
					<LoginAttempt key={index} attempt={attempt} />
				))}
			</ul>
		</div>
	);
};

export default LoginAttemptList;