import ExecutionEnvironment from '@docusaurus/ExecutionEnvironment'

export default (function () {
    if (!ExecutionEnvironment.canUseDOM) {
        return null
    }

    return {
        onRouteUpdate({ location }) {
            setTimeout(() => fathom.trackPageview(), 3000);
        }
    }
})()
