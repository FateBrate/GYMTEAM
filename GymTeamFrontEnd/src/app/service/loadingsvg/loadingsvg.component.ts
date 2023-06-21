import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-loading',
  template: `
    <svg
      [attr.width]="width"
      [attr.height]="height"
      xmlns="http://www.w3.org/2000/svg"
      xmlns:xlink="http://www.w3.org/1999/xlink"
      style="margin: auto; display: block;"
      viewBox="0 0 100 100"
      preserveAspectRatio="xMidYMid"
    >
      <g transform="rotate(0 50 50)">
        <circle
          cx="50"
          cy="50"
          fill="none"
          stroke="#ff0000"
          stroke-width="8"
          r="35"
          stroke-dasharray="164.93361431346415 56.97787143782138"
        >
          <animateTransform
            attributeName="transform"
            type="rotate"
            repeatCount="indefinite"
            dur="2s"
            values="0 50 50;360 50 50"
            keyTimes="0;1"
          ></animateTransform>
        </circle>
      </g>
    </svg>
  `,
  styles: [],
})
export class LoadingsvgComponent {
  @Input() width: number = 100;
  @Input() height: number = 100;
}
