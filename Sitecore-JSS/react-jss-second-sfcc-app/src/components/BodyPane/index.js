import React from 'react';

import LeftPane from '../LeftPane/index.js';
import RightPane from '../RightPane/index.js';

class BodyPane extends React.Component{
  render(){
    return (
      <div className="col-12">
        <LeftPane />
        <RightPane />
      </div>
    );
  }
}

export default BodyPane;
