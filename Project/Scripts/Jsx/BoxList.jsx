var BoxList = React.createClass({
  render: function() {
    return (
	<div>
			<Box />
			<Box />
			<Box />
	</div>
    );
  }
});
ReactDOM.render(
  <BoxList />,
  document.getElementById('content')
);