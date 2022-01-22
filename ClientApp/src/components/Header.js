import React, { Component } from 'react';

export class Header extends Component {
  static displayName = Header.name;

  constructor(props) {
    super(props);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  render() {
    return (
      <div className="container">
        <div className="row">
          <h1 style={{color: "red"}}>Test.co</h1>          
        </div>
        <div className="row">
          <h3 style={{color: "blue"}}>------------</h3>
        </div>
        <div className="row">
          <h3>every small saving helps</h3>
        </div>
      </div>
    );
  }
}
