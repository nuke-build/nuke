import React from 'react';
import InstallButton from "./InstallButton";

function getApiUrl(port, action, pluginId) {
  return action
    ? `http://localhost:${port}/api/installPlugin?action=${action}&pluginId=${pluginId}`
    : `http://localhost:${port}/api/about`
}

export default function RiderInstallButton({url, pluginId, event}) {
  const [detectedPort, setDetectedPort] = React.useState(undefined);
  React.useEffect(async () => {
    for (let i = 63342; i < 63346; i++) {
      try {
        let response = await fetch(getApiUrl(i));
        if (response.status === 404) {
          // let jsonContent = await response.text();
          // let json = JSON.parse(jsonContent);
          // if (json.productName === "Rider") {
            setDetectedPort(i);
            return;
          // }
        }
      } catch {
      }
    }
  }, [])

  return (
    <InstallButton
      url={detectedPort ? getApiUrl(detectedPort, "install", pluginId) : url}
      install={detectedPort !== undefined}
      event={event}/>
  );
}
