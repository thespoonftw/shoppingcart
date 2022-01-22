import React, { Component } from 'react';
import { Product } from './Product';

export class Shop extends Component {
  static displayName = Shop.name;

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
            <Product src="https://images.pexels.com/photos/4775241/pexels-photo-4775241.jpeg" />
            <Product src="https://images.pexels.com/photos/7573152/pexels-photo-7573152.jpeg" />
            <Product src="https://images.pexels.com/photos/10165775/pexels-photo-10165775.jpeg" />
            <Product src="https://images.pexels.com/photos/8743923/pexels-photo-8743923.jpeg" />
            <Product src="https://images.pexels.com/photos/5865461/pexels-photo-5865461.jpeg" />

          </div>
          <div className="col-md">
            <img src="https://i.imgur.com/NFS0WeC.jpg" style={{width: "100%"}} />
          </div>
        </div>
      </div>
    );
  }
}
