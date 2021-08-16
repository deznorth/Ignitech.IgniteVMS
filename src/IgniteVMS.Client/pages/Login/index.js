import React from 'react';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Jumbotron from 'react-bootstrap/Jumbotron';
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import Nav from 'react-bootstrap/Nav';
import Table from 'react-bootstrap/Table';
import Container from 'react-bootstrap/Container';
import ColorSwatch from './ColorSwatch';
import './style.scss';

class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
          email: '',
          password: '',
          errorMessage: null
        };//end state

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }//end constructor

    handleChange(e) {
        const itemName = e.target.itemName;
        const itemValue = e.target.value;
    }

    // handleSubmit(e) {
    //     var registrationInfo = {
    //       email: this.state.email,
    //       password: this.state.password
    //     }
    //     e.preventDefault();
    
    //     //authentication info here
    //     )
    //     .then(() => {
    //       navigate('/');
    //     })
    //     .catch(error => {
    //       if (error.message != null) {
    //         this.setState({errorMessage: error.message});
    //       } 
    //       else {this.setState({errorMessage: null});}
    //     })
    //   }

    render() {
      return (
      <form className="mt-3" onSubmit={this.handleSubmit}>
        <div className="container">
          <div className="row justify-content-center">
            <div className="col-lg-6">
              <div className="card bg-light">
                <div className="card-body">
                  <h3 className="font-weight-light mb-3">Log in</h3>
                  <section className="form-group mb-3">
                  { this.state.errorMessage !== null ? (
                            <FormError theMessage={this.state.errorMessage} />
                          ) : null }
                    <label
                      className="form-control-label visually-hidden-focusable"
                      htmlFor="Email">
                      Email
                    </label>
                    <input
                      required
                      className="form-control"
                      type="email"
                      id="email"
                      name="email"
                      placeholder="Email"
                      value={this.state.email}
                      onChange = {this.handleChange}
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
                      value = {this.state.password}
                      onChange = {this.handleChange}
                    />
                  </section>
                  <div className="form-group float-end mb-0">
                    <button className="btn btn-primary" type="submit">
                      Log in
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </form>
            );
          }
}

export default Login;