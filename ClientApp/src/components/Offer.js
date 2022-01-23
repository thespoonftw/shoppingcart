import React, { Component } from 'react';

export function Offer(props) {
  return (
    <div style={{width: "100%", paddingTop: "2%", paddingLeft: "5%", paddingBottom: "1%", backgroundColor: "#ccc", marginTop: "10px" }}>
          <p>{props.text}</p>
    </div>
  );
}
