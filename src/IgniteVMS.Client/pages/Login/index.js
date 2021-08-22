import React, { useState } from 'react';
import { Redirect } from 'react-router';
import { connect } from 'react-redux';
import * as actions from './modules/actions';

// import Form from 'react-bootstrap/Form';
// import InputGroup from 'react-bootstrap/InputGroup';
// import Nav from 'react-bootstrap/Nav';
// import Table from 'react-bootstrap/Table';
// import Container from 'react-bootstrap/Container';
import '../../app/style.scss';

const handleSubmit = (e, login) => {
  e.preventDefault();
  login(loginEmail.current.value, loginPassword.current.value);
  }

const LoginPage = (props) => {
  const {
    loading, 
    login,
    currentUser,
  } = props;

  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

    return (
      <form className="mt-3" onSubmit = { (e) => {
        e.preventDefault();
        login({username, password});
        }}>
      <div className="container">
        <div className="row justify-content-center">
          <div className="col-lg-6">
            <div className="card bg-white">
              <div className="card-body">
                <h3 className="font-weight-heavy mb-3">Welcome Back!</h3>
                <section className="form-group mb-3">
                  <label
                    className="form-control-label visually-hidden-focusable"
                    htmlFor="text">
                    User Name
                  </label>
                  <input
                    required
                    className="form-control"
                    type="text"
                    id="username"
                    name="username"
                    placeholder="User Name"
                    onChange={e => setUsername(e.target.value)}
                    value={username}
                  />
                </section>
                <section className="form-group mb-3">
                <label
                    className="form-control-label visually-hidden-focusable"
                    htmlFor="password">
                    Password
                  </label>
                  <input
                    required
                    className="form-control"
                    type="password"
                    name="password"
                    placeholder="Password"
                    onChange={e => setPassword(e.target.value)}
                    value={password}
                  />
                </section>
                <div className="form-group float-none mb-0">
                  <button className="btn btn-primary" type="submit" disabled={ loading }>
                    Log in
                  </button>
                  {
                    currentUser ? <Redirect to="/dashboard" /> : null
                  }
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </form>
  )

}

export default connect(
  state => ({
    ...state.pages.login,
  }), {
    login: actions.login  }
)(LoginPage);