import React from 'react';
import BrowserOnly from "@docusaurus/core/lib/client/exports/BrowserOnly";
import Admonition from '@theme/Admonition';

export default function ToolConfirmation() {
  return (
    <BrowserOnly>
      {() => {
        const params = new URL(window.location.href).searchParams;
        return params.get('tool')
          ?
          <div>
            <Admonition type="tip" icon="👍" title="You are in the right place...">
              <p>The <code>{params.get('tool')}Tasks</code> class follows the same principles as described below.</p>
            </Admonition>
          </div>
          : undefined;
      }}
    </BrowserOnly>
  );
}
