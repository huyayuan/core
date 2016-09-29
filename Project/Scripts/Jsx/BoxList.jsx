var BoxList = React.createClass({
	
	componentDidMount: function() {
		$.ajax({
			url: "home/getdata", success: function (data) {

			}
		});
	},
  render: function() {
    return (
	<div>
			<Box data= />
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