import React, { Component } from 'react';

export class Basket extends Component {
  static displayName = Basket.name;

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
          <div className="col-md">
            <img src={this.props.src} style={{width: "100%"}} />
          </div>
        </div>
      </div>
    );
  }
}
