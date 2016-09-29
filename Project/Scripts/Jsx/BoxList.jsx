var BoxList = React.createClass({
	getInitialState: function() {
		return {boxList: []};
	},
	componentDidMount: function() {
		$.ajax({
			url: "home/getdata", success: function (data) {
				this.setState({boxList:data});
			}.bind(this)
		});
	},
  render: function() {
	 var boxList = _.map(this.state.boxList, function(box){
		 return <Box key={box.Id} data={box} />
	 });
    return (
	<div>
		{boxList}
	</div>
    );
  }
});
ReactDOM.render(
  <BoxList />,
  document.getElementById('content')
);