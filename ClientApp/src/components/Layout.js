import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { Shop } from './Shop';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <Shop />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
