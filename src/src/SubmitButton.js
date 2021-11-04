import React from 'react';

class SubmitButton extends React.Component {
  render() {
    return (
      <div className="btn">
        <button
        className='glow-on-hover'
        disabled = {this.props.disabled}
        onClick={ () => this.props.onClick() }
        >
          {this.props.text}

        </button>
      </div>
    );
  }
}

export default SubmitButton;