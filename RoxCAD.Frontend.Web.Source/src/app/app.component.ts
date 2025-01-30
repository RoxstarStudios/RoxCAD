import { Component, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MdtLeaveModalComponent } from './shared/mdt-leave-modal/mdt-leave-modal.component';
import { AxiosService } from './services/axios.service';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MdtLeaveModalComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private axiosService: AxiosService) { }

  envProdOverride: boolean = false;

  pageLoaded = signal(false);

  webServerValid = environment.production ? signal(false) : signal(true);

  async ngOnInit(): Promise<void> {
    // Call the function to fetch and parse the theme CSS
    fetchAndParseThemeCSS();

    if (environment.production) {
      await this.axiosService.validateAPI().then(
        async () => {
          // API check passed
          await this.axiosService.validateWS().then(
            () => {
              // WS check passed
              console.log("RoxCAD Loaded Successfully");
              this.webServerValid.set(true);
            },
            () => {
              // WS check failed, redirect or show error
              console.log("RoxCAD Failed to load.");
              this.webServerValid.set(false);
            }
          );
        },
        () => {
          // API check failed, redirect or show error
          console.log("RoxCAD Failed to load.");
          this.webServerValid.set(false);
        }
      ).finally(() => {
        this.pageLoaded.set(true);
      });
    } else {
      this.pageLoaded.set(true);
    }
  }
}

type SassMap = { [key: string]: string | SassMap };

async function fetchAndParseThemeCSS() {
  try {
    const response = await fetch('assets/config/theme.scss');
    const sassContent = await response.text();

    function parseSassMap(content: string): Record<string, any> {
      const result: Record<string, any> = {};
      const pattern = /([\w-]+):\s*\(((?:[^()]+|\((?:[^()]+|\([^()]*\))*\))*)\)|([\w-]+):\s*([^,]+)/g;
    
      let match;

      while ((match = pattern.exec(content)) !== null) {
        const [_, key, nestedMap, singleKey, singleValue] = match;
        
        if (key && nestedMap) {
          result[key] = parseSassMap(nestedMap.trim()); // Recursively parse nested maps
        } else if (singleKey && singleValue) {
          result[singleKey] = singleValue.trim();
        }
      }

      return result;
    }

    function extractSassMapVariable(sass: string, variableName: string): string | Record<string, any> | null {
      const variableRegex = new RegExp(`\\$${variableName}:\\s*\\(([^]*)\\);`);
      const match = sass.match(variableRegex);

      if (!match) return null;
    
      const mapContent = match[1]?.trim();

      return mapContent ? parseSassMap(mapContent) : null;
    }

    function convertSassToCssVariables(): Record<string, string> {
      const cssVariables: Record<string, string> = {};
      const mapVariables = extractSassMapVariable(sassContent, "theme");

      function processVariables(obj: Record<string, any>, parentKey: string = "--theme") {
        Object.entries(obj).forEach(([key, value]) => {
          const currentKey = `${parentKey}-${key}`;

          if (typeof value === "object" && value !== null) {
            // Recursively process nested objects
            processVariables(value, currentKey);
          } else {
            // Add the CSS variable
            cssVariables[currentKey] = value;
          }
        });
      }

      if (typeof mapVariables === "object") {
        processVariables(mapVariables as Record<string, any>);
      }

      return cssVariables;
    }

    const parsedTheme = convertSassToCssVariables();

    function applyCssVariables(cssVariables: Record<string, string>) {
      const cssString = `:root {\n${Object.entries(cssVariables)
        .map(([key, value]) => `  ${key}: ${value};`)
        .join("\n")}\n}`;
    
      let styleTag = document.getElementById("theme-variables");
      if (!styleTag) {
        styleTag = document.createElement("style");
        styleTag.id = "theme-variables";
        document.head.appendChild(styleTag);
      }
    
      // Set the content of the <style> tag
      styleTag.textContent = cssString;
    }

    applyCssVariables(parsedTheme);
  } catch (error) {
    console.error('Error fetching SASS file:', error);
  }
}