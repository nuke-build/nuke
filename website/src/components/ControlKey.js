import React from 'react';
import BrowserOnly from "@docusaurus/core/lib/client/exports/BrowserOnly";

export default function ControlKey() {
  return (
    <BrowserOnly>
      {() => {
        return <kbd>{navigator.platform.includes("Mac") ? "Command" : "Control"}</kbd>
      }}
    </BrowserOnly>
  );
}
